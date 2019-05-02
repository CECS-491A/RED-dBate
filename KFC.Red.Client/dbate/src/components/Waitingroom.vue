<template>
  <v-layout row wrap>
    <v-flex sm3 offset-xs1 class="scrollable">
      <h1>Players in the Game</h1>
      <h1>Count: {{playerCount}}</h1>
      <players></players>
    </v-flex>
    <v-flex sm3 offset-xs1>
      <div class="text-xs-center">
        <div>
          <v-btn id="startGame" color="blue" v-on:click="startGame" dark large v-if="isMinPlayersMet">Start Game</v-btn>
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
import Loading from '@/components/reusable-components/dialogs/Loading'
import Players from '@/components/reusable-components/Players'
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
    isMinPlayersMet: true, //placeholder for now might work or not 
                            //MIGHT NEED CENTRAL STORE MANAGEMENT HINT: VUEX!
    response: ''
  }),
  mounted (){

  },
  computed: {
    playerCount () {
      return 1;//this.$store.getters.getPlayerAmount;
    }
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
