
<template>
  <v-form
    ref="form"
    class="ml-6 mr-6"
  >
    <v-text-field
      v-model="UserName"
      label="UserName"
      required
    ></v-text-field>

    <v-text-field
      v-model="Password"
      label="Password"
      type="password"
      required
    ></v-text-field>

    <v-btn
      color="primary"
      class="mr-4"

      @click="login"
    >
      Login
    </v-btn>

    </v-form>
</template>

<script>
import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios, axios)

export default ({
    name: 'Login',
    data() {
     return {
       UserName: "",
       Password: "",
     }
    },
    methods: {
      async login() {
        try { 
          var result = await axios.post("https://localhost:44302/api/Login/" +  this.UserName + "/" + this.Password );
          console.warn(result.data.role);
          localStorage.setItem("userName", result.data.userName);
          //console.alert(result.data.UserName);
          localStorage.setItem("userId", result.data.id);
          //admin | user
          if(result.data.role == 0)
            this.$router.push({ name: 'HelloLogged' });
          if(result.data.role == 1)
            this.$router.push({ name: 'get' });
        } catch (e) {
         alert("Incorect credentials!");
        }
      }
    }
})
</script>