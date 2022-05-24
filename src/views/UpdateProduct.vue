<template>
   
         <v-form @submit.prevent="putData"  method="put" >
            
            <input 
                type="text" 
                name="ProductName"
                v-model="posts.ProductName"
                placeholder="ProductName" 
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
                
                
            >Update</v-btn>
        </v-form>
        
</template>

<script>
import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios, axios)

export default ({
    name: 'update',
     data() {
        return {
            posts:{
                Id:this.$route.params.id,
                ProductName:'',
                Category:'',
                Price:null,
                ShopType:''

            }
        }
    },
    methods:{
    async putData(e){
        this.posts.Id = parseInt(this.posts.Id);
        this.posts.Price = parseInt(this.posts.Price);

        //console.log(this.$route.params.id)
        this.axios.put('https://localhost:44302/api/Product/', this.posts)
        this.$router.push({name: 'get'})
        
        e.preventDefault(); 
        
    },



    },
   
})

</script>
