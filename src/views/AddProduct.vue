<template>
   
         <v-form @submit="postData" method="post" >
            <input 
                type="text" 
                name="Name"
                v-model="posts.ProductName"
                placeholder="Name" 
                > 
             
            <input 
                type="text" 
                name="Category" 
                v-model="posts.Category"
                placeholder="Category"
                > 
            <input 
                type="number" 
                name="Price" 
                v-model="posts.Price"
                placeholder="Price"
                > 
            <input 
                type="text" 
                name="Shop Type" 
                v-model="posts.ShopType"
                placeholder="Shop Type"
                >
            <v-btn 
                type ="submit"
                elevation="10" 

            >Add</v-btn>
        </v-form>
        
</template>

<script>
import Vue from 'vue'
import axios, { Axios } from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios, axios)
export default ({
    name: 'add',
     data() {
        return {
            posts:{
                ProductName:null,
                Category:null,
                Price:null,
                ShopType:null

            }
        }
    },
    methods:{
    postData(e){
        
        this.posts.Price = parseInt(this.posts.Price);
        this.axios.post('https://localhost:44302/api/Product/', this.posts)
        this.$router.push({name : 'get'})
        .then((result)=>{
            console.warn(result)
        })
        e.preventDefault();
        //console.warn(result.data.name)
        
    },

    },
   
})

</script>
