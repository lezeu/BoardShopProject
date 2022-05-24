<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <!--<v-btn color="primary" elevation="0" width="150"><router-link :to="'/'">-->
        <div class="d-flex align-center">
          
          <v-img
            alt="Vuetify Logo"
            class="shrink mr-2"
            contain
            :src="require('./assets/shop-logo.png')"
            transition="scale-transition"
            width="40"
          />
          <v-img
            alt="Vuetify Name"
            class="shrink mt-1 hidden-sm-and-down"
            contain
            min-width="100"
            :src="require('./assets/shop-font.png')"
            transition="scale-transition"
            width="100"
          />
          
        </div>
      <!--</router-link></v-btn>-->

      <v-spacer></v-spacer>

      
        
      

    </v-app-bar>

    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script>

export default ({
  name: 'App',

  data() {
    return {
      UserName:this.$route.params.UserName,
      Role:this.$route.params.Role
    }
  },
  
  async mounted(e){
    var res = this.Role
  }

});
</script>
