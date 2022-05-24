<template>
  <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
          
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
          :key="item.favId"
        >
          <td>{{ item.productNameFav }}</td>
          <td>{{ item.categoryFav }}</td>
          <td>{{ item.priceFav }}</td>
          <td>{{ item.shopTypeFav }}</td>
          <td> <v-btn @click="deleteClient(item.favId)">Delete</v-btn> </td>
          
        </tr>
      </tbody>        
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
        return{ list:undefined}
    },
    
    async mounted(e){
            
        await Vue.axios.get('https://localhost:44302/api/Fav/')
        .then((result)=>{
            this.list = result.data;
            console.warn(result.data)
        })
        
        },
    methods :{
      async deleteClient(id) {
        try { 
          console.log(id);
          var result = await axios.delete('https://localhost:44302/api/Fav/' +  id);
          var result = await axios.get('https://localhost:44302/api/Fav/');
          this.list = result.data;
        } catch (e) {

        }
      }
    },
    
})
</script>