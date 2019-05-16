<template>
  <v-layout row wrap>
    <v-flex sm3 offset-xs1 class="scrollable">
      <br/>
      <h1>Winning Team is: {{this.$store.getters.getPlayerAmount}}</h1>
    </v-flex>
    <v-flex sm3 offset-xs1>
      <div class="text-xs-center">
        <div>
          <v-btn id="Team1" color="blue" v-on:click="chooseTeam1" dark large v-if="this.$store.getters.getGameRole==='Host'">Team 1</v-btn>
        </div>
      </div>
    </v-flex>
    <v-flex sm3 offset-xs1>
      <div class="text-xs-center">
        <div>
          <v-btn id="Team2" color="blue" v-on:click="chooseTeam2" dark large v-if="this.$store.getters.getGameRole==='Host'">Team 2</v-btn>
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
  </v-layout>
</template>
<script>
import Players from '@/components/chatroom/Players'
import axios from "axios"
import {URL} from '@/services/ConstUrls'

export default {
  name: 'DecideWinner',
  components: {
    Players
  },
  data: () => ({
      interval: null
  }),
  mounted (){
      this.interval = setInterval(this.isThereWinner, 3000);
  },
  methods: {
    endWait(){
      let gameSession = localStorage.getItem('gameSessionToken');
      axios.delete(URL.deleteGameSessionURL + '?gameSessionToken=' + gameSession)
      .then(resp => {
        this.response = resp.data;
        this.$router.push('/lobby');
      })
      .catch(e => {
          this.response = e.data;
      })

    },
    chooseTeam1(){
        axios.get(URL.decideWinnerURL,{
            params:{
                gameSessionToken: localStorage.getItem('gameSessionToken'),
                role: 'Team1'
            }
        })
        .then(resp => {
            let info = resp.data;
            this.displayWinner('Team1');
            this.endWait();
            this.$router.push('/lobby');
        })
        .catch(e => {
            this.error = e.response;
            console.log(this.error);
            this.$router.push('/lobby');

        })

    },
    chooseTeam2(){
        axios.get(URL.decideWinnerURL,{
            params:{
                gameSessionToken: localStorage.getItem('gameSessionToken'),
                role: 'Team2'
            }
        })
        .then(resp => {
            let info = resp.data;
            this.displayWinner('Team2');
            this.endWait();
            this.$router.push('/lobby');
        })
        .catch(e => {
            this.error = e.response;
            console.log(this.error);
            this.$router.push('/lobby');
        })

    },
    displayWinner(role){
        alert(role + 'is the winner!');
    },
    isThereWinner(){
      axios.get(URL.isThereWinnerURL,{
        params: {
          gameSessionToken: localStorage.getItem('gameSessionToken')
        }
      })
      .then(resp => {
        let info = resp.data;
        console.log('test:' + info);
        if(info==='Team1'){
            this.displayWinner(info);
            this.$router.push('/lobby');
            clearInterval(this.interval);
        }
        else if(info === 'Team2'){          
          this.displayWinner(info);
          this.$router.push('/lobby');
          clearInterval(this.interval);          
        }        
      })
      .catch( e =>{
        this.error = e.response;
        this.$router.push('/lobby');
        clearInterval(this.interval);
      })
    }
  }
  

}
</script>
