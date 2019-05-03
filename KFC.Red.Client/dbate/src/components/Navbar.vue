<template>
  <v-toolbar color="primary">
    <v-toolbar-title class="ml-0 pl-3">
      <span><strong class="white--text text--lighten-1">Dbate</strong></span>
    </v-toolbar-title>
    <v-spacer></v-spacer>

    <v-btn to="home"  flat><strong class="white--text text--lighten-1">Home</strong></v-btn>
    <v-btn to="about" flat><strong class="white--text text--lighten-1">About</strong></v-btn>
    <v-btn to="lobby" flat v-if="isSessionStored===false"><strong class="white--text text--lighten-1">Lobby</strong></v-btn>
    <v-btn to="admindashboard" flat v-if="isSessionStored===false"><strong class="white--text text--lighten-1">Admin Portal</strong></v-btn>
    <v-btn v-on:click="logout" v-if="isSessionStored===true">Logout</v-btn>
    <v-btn v-on:click="login" v-if="isSessionStored===false">Login</v-btn>
    <div v-if="showPopup">
      <PopupDialog :dialog="showPopup" :text="popupMessage" :redirect="false"/>
    </div>
  </v-toolbar>

</template>

<script>
import axios from "axios"
import {URL} from '@/services/ConstUrls'
import PopupDialog from '@/components/dialogs/PopupDialog.vue'
import {KFC_LoginURL} from '@/services/ConstUrls'
import { EventBus } from '@/services/EventBus'

export default {
  name: 'Navbar',
  components: {
    PopupDialog
  },
  data() {
    return {
      showPopup: false,
      popupMessage: '',
      routeTo: '/home'
    }
  },
  computed: {
    isSessionStored: function(){
      if(localStorage.getItem('token') !== null){
        return true;
      }
      else{
        return false;
      }
    }
  },
  methods: {
    logout(){
      console.log(localStorage.getItem('token'));
      alert("You will now logout" + localStorage.getItem('token'));
      axios.post(URL.logoutURL,{
        Token: localStorage.getItem('token')
      })
      .then(resp => {
        this.showPopup = true;
        this.popupMessage = 'User has logged out';
        localStorage.removeItem('token');
        //window.location.href = KFC_LoginURL;
      })
      .catch(e => {
        console.log(e.data);
        this.showPopup = true;
        this.popupMessage = 'User has logged out';
        localStorage.removeItem('token');
        //window.location.href = KFC_LoginURL;
      })
    },
    login(){
        window.location.href = KFC_LoginURL;
    }
  }
}
</script>

<style>
body {
  margin: 0;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

main {
  text-align: center;
  margin-top: 0px;
}

header {
  margin: 0;
  height: 56px;
  padding: 0 16px 0 24px;
  background-color: #35495E;
  color: #ffffff;
}

header span {
  display: block;
  position: relative;
  font-size: 20px;
  line-height: 1;
  letter-spacing: .02em;
  font-weight: 400;
  box-sizing: border-box;
  padding-top: 16px;
}
</style>
