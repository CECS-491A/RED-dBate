    
<template>
  <v-layout row wrap>
    <v-flex sm2 offset-xs1 class="scrollable">
      <v-heading>Team Members</v-heading>
      <players></players>
    </v-flex>

    <v-flex sm2 offset-xs1 class="scrollable">
      <v-heading>Moderator</v-heading>
      <players></players>
    </v-flex>

    <v-flex sm2 offset-xs1 class="scrollable">
      <v-heading>Opposing Team</v-heading>
      <players></players>
    </v-flex>
    
    <v-flex xs8 offset-xs1 style="position: relative;">
      <div class="chat-container" v-on:scroll="onScroll" ref="chatContainer" >
      </div>
      <div class="typer">
        <input type="text" placeholder="Type here..." v-on:keyup.enter="sendMessage" v-model="content">
        <v-btn icon class="blue--text emoji-panel" @click="toggleEmojiPanel">
          <v-icon>mood</v-icon>
        </v-btn>
      </div>
    </v-flex>
  </v-layout>
</template>
<script>
  //import Message from './Message.vue'
  //import EmojiPicker from './EmojiPicker.vue'
  import Players from '@/components/reusable-components/Players.vue'
  //import * as firebase from 'firebase'
  export default {
    data () {
      return {
        content: '',
        chatMessages: [],
        emojiPanel: false,
        currentRef: {},
        loading: false,
        totalChatHeight: 0
      }
    },
    props: [
      'id'
    ],
    mounted () {
      this.loadChat()
      this.$store.dispatch('loadOnlineUsers')
    },
    components: {
      //'message': Message,
      //'emoji-picker': EmojiPicker,
      'players': Players
    },
    computed: {
      messages () {
      },
      username () {
      },
      onChildAdded () {

      }
    },
    watch: {
      '$route.params.id' (newId, oldId) {
        this.currentRef.off('child_added', this.onChildAdded)
        this.loadChat()
      }
    },
    methods: {
      loadChat () {
      },
      onScroll () {
      },
      processMessage (message) {
      },
      sendMessage () {
        
      },
      scrollToEnd () {
      
      },
      scrollTo () {
      },
      addMessage (emoji) {
      },
      toggleEmojiPanel () {      
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
  .typer .emoji-panel{
    /*margin-right: 15px;*/
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