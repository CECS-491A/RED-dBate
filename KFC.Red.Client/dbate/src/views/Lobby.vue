<template>
  <v-container fluid class="pa-0">
    <h4 class="display-3">The Lobby</h4>
    <br/>
     <v-layout justify-center>
        <div class="text-xs-center">
          <div>
            <v-btn id="joinRandomChat" color="blue" v-on:click="joinRandomChat" dark large>Join Random Room</v-btn>
          </div>
        </div>
        <div class="text-xs-center">
          <div>
            <v-btn id="createChat" color="blue" v-on:click="createChat" dark large>Create Chat Room</v-btn>
          </div>
        </div>
      </v-layout> 
              <v-alert
            :value="error"
            type="error"
            transition="scale-transition"
        >
            {{error}}
        </v-alert>

        <br />
  </v-container>
</template>

<script>
import axios from "axios"
import {URL} from '@/services/ConstUrls'

export default {
    name: 'lobby',
    data () {
        return {
            error: ""
        }
    },
    methods:{
        createChat(){
            axios.get(URL.createChatURL,{
              params: {
                token: localStorage.getItem('token')
              }
            })
            .then(t => {
              let key = t.data;
              let playerAmount = this.$store.getters.getPlayerAmount;
              localStorage.setItem('gameSessionToken',t.data);
              console.log(t.data);
              getPlayerCount();
              //this.$store.dispatch('actPlayerAmount', {PlayerAmount: playerAmount + 1});
              this.$router.push('/waitingroom/' + key);
            })
            .catch(e => {
                this.error = e.response;
            })
        },
        getPlayerCount(){
          axios.get(URL.getPlayerCountURL, {
            params: {
              gameSessionToken: localStorage.getItem('gameSessionToken')
            }
          })
          .then( resp => {
            let playerCount = resp.data;
            this.$store.dispatch('actPlayerAmount', {PlayerAmount: playerCount});
          })
          .catch(e => {
            this.error = e.response;
          })
        },
        joinRandomChat(){
          axios.get(URL.joinRandomChatURL,{
            params: {
                token: localStorage.getItem('token')
            }
          })
          .then(t => {
            let key = t.data;
            let playerAmount = this.$store.getters.getPlayerAmount;
            localStorage.setItem('gameSessionToken',t.data);
            this.$store.dispatch('actPlayerAmount', {PlayerAmount: playerAmount + 1});
            this.$router.push('/waitingroom/' + key)
          })
          .catch(e => {
            this.error = e.response;
          })
        }
    }
}
</script>
