<template>
    <v-layout row-wrap>
     <v-flex sm3 offset-xs1 class="scrollable">
        <h1>Team 1</h1>
        <v-list-tile>
          <ul v-if="this.userList">
            <li v-for="item in this.userList" v-if="item.Role==='Team1'"> <strong>{{item.Email}}</strong></li>
          </ul>
        </v-list-tile>
     </v-flex>
     <v-flex sm3 offset-xs1 class="scrollable">
        <h1>Moderator</h1>
        <v-list-tile>
          <ul v-if="this.userList">
            <li v-for="item in this.userList" v-if="item.Role==='Host'"> <strong>{{item.Email}}</strong></li>
          </ul>
        </v-list-tile>
     </v-flex>
     <v-flex sm3 offset-xs1 class="scrollable">
        <h1>Team 2</h1>
        <v-list-tile>
       <ul v-if="this.userList">
            <li v-for="item in this.userList" v-if="item.Role==='Team2'"> <strong>{{item.Email}}</strong></li>
          </ul>
        </v-list-tile>
     </v-flex>
  </v-layout>

</template>

<script>
  import axios from "axios"
  import {URL} from '@/services/ConstUrls'

  export default {
    data () {
      return {
        userList: [],
        userPlaying: 'users playing'
      }
    },
    mounted (){
      this.getUsers()
    },
    methods: {
      getUsers(){
        axios.get(URL.getGameUsersURL,{
          params:{
            gameSessionToken: localStorage.getItem('gameSessionToken')
          }
        })
        .then(resp => {
          this.userList = resp.data;
        })
        .catch();
      }
    }
  }
</script>