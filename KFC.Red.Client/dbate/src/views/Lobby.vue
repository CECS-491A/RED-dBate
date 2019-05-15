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
import {chatServerURL} from '@/services/ConstUrls'

export default {
    name: 'lobby',
    data () {
        return {
            error: "",
            connection: null,
            proxy: null
        }
    },
    mounted (){
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
              localStorage.setItem('gameSessionToken',key.Token);
              console.log(t.data + '\n' + key.Token + '\n' + key.PlayerCount);
              this.$store.dispatch('actPlayerAmount', {PlayerAmount: key.PlayerCount});
              this.$store.dispatch('actQuestion', {Question: key.Question });
              this.$store.dispatch('actGameRole',{GameRole: key.GameRole});
              this.$router.push('/waitingroom/' + key.Token)

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
            localStorage.setItem('gameSessionToken',key.Token);
            this.$store.dispatch('actPlayerAmount', {PlayerAmount: key.PlayerCount});
            this.$store.dispatch('actQuestion', {Question: key.Question });
            this.$store.dispatch('actGameRole',{GameRole: key.GameRole});
            this.$router.push('/waitingroom/' + key.Token)
          })
          .catch(e => {
            this.error = e.response;
          })
        }
    }
}
</script>
