<template>
  <v-list subheader>
  <v-subheader>uuu</v-subheader>
    <v-list-tile avatar v-for="(user) in users" v-bind:key="user.name">
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
    computed: {
      users () {
        return this.$store.getters.getPlayerList;
      }
    },
    watch: {
      users (oldList, newList) {
        axios.get()
        .then(resp => {
          let newPlayer = resp.data;
          this.$store.dispatch('actGetPlayerList',{});
        })
        .catch(error => {

        })
      }
    }
  }
</script>