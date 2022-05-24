<template>
  <v-form
    ref="form"
    class="ml-6 mr-6"
  >
    <v-text-field
      v-model="username"
      label="Username"
      required
    ></v-text-field>


    <v-text-field
      v-model="email"
      label="Email"
      required
    ></v-text-field>

    <v-text-field
      v-model="password"
      label="Password"
      type="password"
      required
    ></v-text-field>

    <v-btn
      color="primary"
      class="mr-4"
      @click="singUp"
    >
      SingUp
    </v-btn>
  </v-form>
</template>

<script>
  import axios from "axios";
  export default ({
    name: 'login',
    data() {
      return {
        username: "",
        password: "",
        email: ""
      }
    },
    methods: {
      async singUp() {
        try { 
          var result = await axios.post("https://localhost:44302/api/LogIn", { username: this.username, email: this.email, password: this.password });
          this.$router.push({ name: 'LogIn' });
        } catch (e) {
          
        }
      }
    }
  })
</script>
