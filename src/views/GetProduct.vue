
<template>
  <v-simple-table>    
    <template v-slot:default>
      <thead>
        <tr>
          <!--<th class="text-left">
            Image
          </th>-->
          <th class="text-left">
            ProductName
          </th>
          <th class="text-left">
            Category
          </th>
           <th class="text-left">
            Price
          </th>
          <th class="text-left">
            ShopType
          </th>
           <th class="text-left">
            <!--Action -->
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in list"
          :key="item.id"
        >
          <!--<td>{{ item.image }}</td>-->
          <td>{{ item.productName }}</td>
          <td>{{ item.category }}</td>
          <td>{{ item.price }}</td>
          <td>{{ item.shopType }}</td>
          <td>
            <!--<v-btn @click="$router.push('/Cart/' + item.id)" > Add to cart </v-btn>-->
            <!--<v-btn> <router-link :to="'/Cart/' + item.id + '/' + item.productName + '/' + item.category + '/' + item.price + '/'  + item.shopType">  Add to cart </router-link> </v-btn>-->
            <v-btn @click="addCart(item.id, item.productName, item.category, item.price, item.shopType)"> Add </v-btn>
            <v-btn @click="addFav(item.id, item.productName, item.category, item.price, item.shopType)"> Favourite </v-btn> </td>
          
        </tr>
      </tbody>      
      <v-btn> <router-link :to="'/Cart'">View cart </router-link></v-btn>
      <v-btn> <router-link :to="'/Fav'">Favourite </router-link></v-btn>
      <v-btn> <router-link :to="'/logged'">Home </router-link></v-btn>
      
    </template>
  </v-simple-table>
  
</template>

<script>
import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios, axios)

export default ({
    name : "GetProduct",
    data(){
        return{ 
          list:undefined,
        }

    },


     
    async mounted(e){
            
        await Vue.axios.get('https://localhost:44302/api/Product/')
        .then((result)=>{
            this.list = result.data;
            console.warn(result.data)
        })
        
        },
    methods :{
      async addCart(id, productName, category, price, shopType) {
        try{
          this.axios.post('https://localhost:44302/api/Cart/' + id + '/' + productName + '/' + category + '/' + price + '/'  + shopType)
          .then((result) =>{
            console.warn(result)
          })
          e.preventDefault(result);
        } catch (e) {

        }
      },

      

      async addFav(id, productName, category, price, shopType) {
        try{
          this.axios.post('https://localhost:44302/api/Fav/' + id + '/' + productName + '/' + category + '/' + price + '/'  + shopType)
          .then((result) =>{
            console.warn(result)
          })
          e.preventDefault(result);
        } catch (e) {

        }
      }
    },
    
})
</script>