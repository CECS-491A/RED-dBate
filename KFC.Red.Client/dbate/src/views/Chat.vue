    
<template>
   <v-container fluid grid-list-xl>
  <v-layout row wrap>
    <v-flex sm3 offset-xs1 class="scrollable">
      <h1>Team Members</h1>
      <players></players>
    </v-flex>

    <v-flex sm3 offset-xs1 class="scrollable">
      <h1>Moderator</h1>
      <players></players>
    </v-flex>

    <v-flex sm3 offset-xs1 class="scrollable">
      <h1>Opposing Team</h1>
      <players></players>
    </v-flex>
  </v-layout
  >
  <v-layout>
    <v-flex sm4 offset-xs1 style="position: relative;"  v-if="this.$store.getters.getPlayerAmount > 3">
      <v-toolbar-title>Group Chat Room</v-toolbar-title>
      <div class="chat-container" ref="chatContainer" >
      
      </div>
      <div class="typer">
        <input type="text" placeholder="Type here...">
      </div>
    </v-flex>

    <v-flex sm8 offset-xs1 style="position: relative;">      
      <v-toolbar-title>Question: {{this.$store.getters.getQuestion}}</v-toolbar-title>
      <div class="chat-container" ref="chatContainer" >
        <ul v-if="this.$store.getters.getMessages">
          <li v-for="item in this.$store.getters.getMessages"> <strong>{{item.username}}</strong> : {{item.message}}</li>
        </ul>
      </div>
      <div class="typer">
        <input type="text" placeholder="Type here..." v-on:keyup.enter="sendMessage" v-model="message">
      </div>
    </v-flex>
  </v-layout>
   </v-container>
</template>

<script>
  import axios from "axios"
  import Players from '@/components/chatroom/Players.vue'
  import $ from 'jquery'
  import 'ms-signalr-client-jquery-3'
  import {URL} from '@/services/ConstUrls'
  import {chatServerURL} from '@/services/ConstUrls'

  export default {
    data () {
      return {
        messages: [],
        message: '',
        username: '',
        users: [],
        connection: null,
        proxy: null
      }
    },
    mounted () {
      this.username = this.$store.getters.getEmail;
      this.connection = $.hubConnection(chatServerURL);
      this.proxy = this.connection.createHubProxy('HubService');
      
      this.proxy.on('messageReceived', (username, message) => {
          console.log("Server message: " + this.message);
          this.$store.dispatch('actMessages', {Messages: {username: username, message: message}});
      });
      
      this.connection
        .start({ })
        .done(() => { console.log('Now connected') })
        .fail((e) => { console.log('Could not connect' + e.data) })
    },
    components: {
      'players': Players
    },
    methods: {
      sendMessage (){
        
        axios.post(URL.sendMsgURL,{
          Username: this.username,
          Message: this.message
        })
        .then( m => {
          console.log(m.data);
        }
        )
        .catch(
          error => {
            console.log(error.data);
          }
        )
      }
    },
  }
</script>

<style>
  .scrollable {
    overflow-y: auto;
    height: 20vh;
  }
  .typer{
    box-sizing: border-box;
    display: flex;
    align-items: center;
    bottom: 0;
    height: 4.9rem;
    width: 100%;
    background-color: #fff;
    box-shadow: 0 -5px 10px -5px rgba(0,0,0,.2);
  }

  .typer input[type=text]{
    position: absolute;
    left: 2.5rem;
    padding: 1rem;
    width: 80%;
    background-color: transparent;
    border: none;
    outline: none;
    font-size: 1.25rem;
  }
  .chat-container{
    box-sizing: border-box;
    height: calc(100vh - 9.5rem);
    overflow-y: auto;
    padding: 10px;
    background-color: #f2f2f2;
  }
  .message{
    margin-bottom: 3px;
  }
  .message.own{
    text-align: right;
  }
  .message.own .message{
    background-color: lightskyblue;
  }
  .chat-container .username{
    font-size: 18px;
    font-weight: bold;
  }
  .chat-container .message{
    padding: 8px;
    background-color: lightgreen;
    border-radius: 10px;
    display:inline-block;
    box-shadow: 0 1px 3px 0 rgba(0,0,0,0.2), 0 1px 1px 0 rgba(0,0,0,0.14), 0 2px 1px -1px rgba(0,0,0,0.12);
    max-width: 50%;
    word-wrap: break-word;
    }
  @media (max-width: 480px) {
    .chat-container .message{
      max-width: 60%;
    }
  }
</style>