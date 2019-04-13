    
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
    <v-flex sm4 offset-xs1 style="position: relative;">
      <v-toolbar-title>Group Chat Room</v-toolbar-title>
      <div class="chat-container" ref="chatContainer" >
      
      </div>
      <div class="typer">
        <input type="text" placeholder="Type here..." v-on:keyup.enter="sendMessage" v-model="content">
      </div>
    </v-flex>

    <v-flex sm8 offset-xs1 style="position: relative;">      
      <v-toolbar-title>Question: {{this.question}}</v-toolbar-title>
      <div class="chat-container" ref="chatContainer" >
        <ul v-if="messages">
          <li v-for="item in messages"> <strong>{{item.username}}</strong> : {{item.message}}</li>
        </ul>
      </div>
      <div class="typer">
        <input type="text" placeholder="Type here..." v-on:keyup.enter="sendMessage" v-model="content">
      </div>
    </v-flex>
  </v-layout>
   </v-container>
</template>
<script>
  import axios from "axios"
  import Players from '@/components/reusable-components/Players.vue'
  import $ from 'jquery'
  import 'ms-signalr-client-jquery-3'

  export default {
    data () {
      return {
        question: '',
        messages: [],
        content: '',
        chathub: $.connection.DBateChatHub,
        username: '',
        users: []
      }
    },
    mounted () {
      //this.username = localStorage.getItem('username')
      //let that = this
      //this.connection = $.hubConnection('http://localhost:5000/signalr')
      //this.proxy = this.connection.createHubProxy('DBateChatHub')
      this.randomQuestion()
    },
    components: {
      'players': Players
    },
    methods: {
      sendMessage () {
        const url = 'http://localhost:5000/api/chat/postmessage'
        //const url = ''
        axios.post(url,{
          Id: 1,
          UserId: 1111,
          Username: 'Bill',
          Message: 'hi' ,
          DateTime: '2/2/22'
        }).then(msg => {
          this.username = 'bill'
          this.message = 'hi'
          this.messages.push(this.username,this.messages)
          console.log(msg + "h")
        })
        .catch(e => {console.log("error: " + e)});
      },
      randomQuestion () {
        const url ='http://localhost:5000/api/question/randomquestion'
        //const url = 'https://thedbate.azurewebsites.net/backend/api/question/randomquestion';
        axios.get(url)
        .then(qst => {this.question = qst.data; console.log(this.question + "ddd")})
        .catch(e => {console.log("error: " + e.data)}) 
      }
    }
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
  .message.own .content{
    background-color: lightskyblue;
  }
  .chat-container .username{
    font-size: 18px;
    font-weight: bold;
  }
  .chat-container .content{
    padding: 8px;
    background-color: lightgreen;
    border-radius: 10px;
    display:inline-block;
    box-shadow: 0 1px 3px 0 rgba(0,0,0,0.2), 0 1px 1px 0 rgba(0,0,0,0.14), 0 2px 1px -1px rgba(0,0,0,0.12);
    max-width: 50%;
    word-wrap: break-word;
    }
  @media (max-width: 480px) {
    .chat-container .content{
      max-width: 60%;
    }
  }
</style>