<template>
  <v-layout row wrap>
    <v-flex sm3 offset-xs1 class="scrollable">
      <br/>
      <h1>Players in the Game: {{this.$store.getters.getPlayerAmount}}</h1>
      <players></players>
    </v-flex>
    <v-flex sm3 offset-xs1>
      <div class="text-xs-center">
        <div>
          <v-btn id="startGame" color="blue" v-on:click="startGame" dark large v-if="this.$store.getters.getIsPlayerMinimumMet">Start Game</v-btn>
        </div>
      </div>
    </v-flex>
    <v-flex sm3 offset-xs1>
      <div class="text-xs-center">
        <div>
          <v-btn id="endWait" color="blue" v-on:click="endWait" dark large>End Game</v-btn>
        </div>
      </div>
    </v-flex>
    <div v-if="loading">
      <Loading :dialog="loading" :text="loadingText"/>
    </div>
  </v-layout>
</template>

<script>
import Loading from '@/components/dialogs/Loading'
import Players from '@/components/chatroom/Players'
import axios from "axios"
import {URL} from '@/services/ConstUrls'

export default {
  name: 'Waitingroom',
  components: {
    Loading,
    Players
  },
  data: () => ({
    loading: true,
    loadingText: 'Gathering More Players...',
    validSession: true,
    popupMessage: '',
    response: ''
  }),
  mounted (){

  },
  watch: {
    playerCount (newCount, oldCount) {
      console.log("count: " + newCount);
      if(newCount === 3 ){
        this.isMinPlayersMet = true;
        this.loadingText = 'Minimum Amount of Players is met, you may start now';
      }
    }
  },
  methods: {
    startGame(){
      let gameSession = localStorage.getItem('gameSessionToken');
      this.$router.push('/chat/' + gameSession);
    },
    endWait(){
      let gameSession = localStorage.getItem('gameSessionToken');
      axios.delete(URL.deleteGameSessionURL + '?gameSessionToken=' + gameSession)
      .then(resp => {
        this.loading = false;
        this.response = resp.data;
        this.$router.push('/lobby');
      })
      .catch(e => {
          this.response = e.data;
      })
    }
  }

}
</script>

<style>

</style>
