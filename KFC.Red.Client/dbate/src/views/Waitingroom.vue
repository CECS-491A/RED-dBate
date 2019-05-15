<template>
  <v-layout row wrap>
    <v-flex sm3 offset-xs1 class="scrollable">
      <br/>
      <h1>Players in the Game: {{this.$store.getters.getPlayerAmount}}</h1>
      <!--<players></players>-->
    </v-flex>
    <v-flex sm3 offset-xs1>
      <div class="text-xs-center">
        <div>
          <v-btn id="runGame" color="blue" v-on:click="runGame" dark large v-if="this.$store.getters.getGameRole==='Host'">Start Game</v-btn>
        </div>
      </div>
    </v-flex>
    <v-flex sm3 offset-xs1>
      <div class="text-xs-center">
        <div>
          <v-btn id="leaveGame" color="blue" v-on:click="leaveGame" dark large>Leave Game</v-btn>
        </div>
      </div>
    </v-flex>    
    <v-flex sm3 offset-xs1>
      <div class="text-xs-center">
        <div>
          <v-btn id="endWait" color="blue" v-on:click="endWait" dark large v-if="this.$store.getters.getGameRole==='Host'">End Game</v-btn>
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
    users: [],
    loadingText: 'Gathering More Players...',
    validSession: true,
    popupMessage: '',
    response: '',
    interval: null
  }),
  mounted (){
      this.interval = setInterval(this.runInterval, 3000);
  },
  methods: {
    runGame(){
      this.useGSession();
      this.startGame();
    },
    runInterval(){
      this.getPlayerCount();
      this.isGSessionUsed();
    },
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

    },
    leaveGame(){
      let session = localStorage.getItem('token');
      axios.delete(URL.leaveGameURL + '?sessionToken=' + session)
      .then(resp => {
        this.loading = false;
        this.response = resp.data;
        this.$router.push('/lobby');
      })
      .catch(e =>{
        this.response = e.data;
      })
    },
    getPlayerCount(){
        axios.get(URL.getPlayerCountURL,{
          params: {
            gameSessionToken: localStorage.getItem('gameSessionToken')
          }
        })
        .then(t => {
          let key = t.data;
          this.$store.dispatch('actPlayerAmount', {PlayerAmount: key});
          console.log('playercount: ' + key);
        })
        .catch(e =>{
          this.error = e.response;
        })
    },
    useGSession(){
      axios.get(URL.useGSessionURL,{
        params: {
          gameSessionToken: localStorage.getItem('gameSessionToken') 
        }
      })
      .then(resp =>{
        this.response = resp.data;
      })
      .catch(e =>{
        this.error = e.data;
      })
    },
    isGSessionUsed(){
      axios.get(URL.isGSessionUsedURL,{
        params: {
          gameSessionToken: localStorage.getItem('gameSessionToken')
        }
      })
      .then(resp => {
        let info = resp.data;
        if(info){          
          this.startGame();
          clearInterval(this.interval);
          
        }        
      })
      .catch( e =>{
        this.error = e.response;
        this.$router.push('/lobby');
        clearInterval(this.interval);
      })
    },
  }
  

}
</script>

<style>

</style>
