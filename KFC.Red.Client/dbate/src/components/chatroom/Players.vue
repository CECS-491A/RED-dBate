<template>
  <v-list subheader>
    <v-list-tile>
      <!--{{this.$store.getters.getPlayerList}}!-->
      <ul v-if="this.$store.getters.getPlayerList">
        <li v-for="item in this.$store.getters.getPlayerList"> <strong>{{item}}</strong></li>
      </ul>
    </v-list-tile>
  </v-list>
</template>

<script>
  import axios from "axios"
  import {URL} from '@/services/ConstUrls'

  export default{
    data () {
      return {
        userPlaying: 'users playing'
      }
    },
    watch: {
      users (oldList, newList) {
        axios.get()
        .then(resp => {
          let newPlayer = resp.data;
          //this.$store.dispatch('actGetPlayerList',{});
        })
        .catch(error => {

        })
      }
    }
  }
</script>