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
          v-for="item in filterUser(prodId)"
          :key="item.cartId"
        >
          <td>{{ item.productNameCart }}</td>
          <td>{{ item.categoryCart }}</td>
          <td>{{ item.priceCart }}</td>
          <td>{{ item.shopTypeCart }}</td>
          <td> <v-btn @click="deleteClient(item.cartId)">Delete</v-btn> </td>
          
        </tr>
      </tbody>        
      <!--<v-btn @click="PlaceOrder(item.cartId, item.productName, item.category, item.price, item.shopType)">Place Order</v-btn>-->  
      <!--<v-btn @click ="Place_Order(cartId)">Place Order</v-btn>-->
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
    beforeMount(){
      this.prodId = localStorage.getItem("userId")
    },
    async mounted(e){
            
        await Vue.axios.get('https://localhost:44302/api/Cart/')
        .then((result)=>{
            this.list = result.data;
            console.warn(result.data)
        })
        
        },
    methods :{
      async deleteClient(id) {
        try { 
          console.log(id);
          var result = await axios.delete('https://localhost:44302/api/Cart/' +  id);
          var result = await axios.get('https://localhost:44302/api/Cart/');
          this.list = result.data;
        } catch (e) {

        }
      },
      filterUser:function(i){
        return this.item.filter(item => item.prodId === i)
      },
      async PlaceOrder(cartId,  productName, category, price, shopType){
        this.axios.post('https://localhost:44302/api/CheckOut/'  + cartId + '/' + productName + '/' + category + '/' + price + '/'  + shopType)
      },
      async Place_Order(id){
        //notify that the order was placed
        for(const i in id){
          var result = await axios.delete('https://localhost:44302/api/Cart/' +  i);
        }
      }
    },
    
})
</script>