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
          :key="item.id"
        >
          <td>{{ item.productName }}</td>
          <td>{{ item.category }}</td>
          <td>{{ item.price }}</td>
          <td>{{ item.shopType }}</td>
          <td><v-btn> <router-link :to="'/Product/update/' + item.id">Update </router-link> </v-btn>
          <v-btn @click="deleteClient(item.id)">Delete</v-btn> </td>
          
        </tr>
      </tbody>      
      <v-btn> <router-link :to="'/Product/'">Add </router-link></v-btn>
      <v-btn> <router-link :to="'/'">Log Out </router-link></v-btn>
      
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
            
        await Vue.axios.get('https://localhost:44302/api/Product/')
        .then((result)=>{
            this.list = result.data;
            console.warn(result.data)
        })
        
        },
    methods :{
      async deleteClient(id) {
        try { 
          var result = await axios.delete('https://localhost:44302/api/Product/' +  id);
          var result = await axios.get('https://localhost:44302/api/Product/');
          this.list = result.data;
        } catch (e) {

        }
      }
    },
    
})
</script>