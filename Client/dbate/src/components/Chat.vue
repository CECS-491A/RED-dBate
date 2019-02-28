<template>
  <div>
    <div class="chat">
    </div>
    <input type="text" v-model="message"/>
    <button v-on:click="sendMessage">Send Message</button>
    <ul v-if="messages">
      <li v-for="item in messages">{{ item }}</li>
    </ul>
  </div>
</template>

<script>
  import $ from 'jquery'
  import 'ms-signalr-client-jquery-3'

  export default {
    name: 'chat',
    data () {
      return {
        message: '',
        messages: [],
        connection: null,
        proxy: null,
      }
    },
    beforeMount () {
      let that = this
      this.connection = $.hubConnection('http://localhost:5000/signalr')
      this.proxy = this.connection.createHubProxy('ChatHub')
      this.proxy.on('sendMessageToClients', (message) => {
        console.log('test')
        that.messages.push({ message: message })
      })
      this.connection
        .start({ })
        .done(() => { console.log('Now connected') })
        .fail(() => { console.log('Could not connect') })
    },
    methods: {
      sendMessage () {
        this.proxy.invoke('send', this.message)
        .done(() => { console.log('Invocation of Send succeeded') })
        .fail(error => { console.log('Invocation of Send failed. Error: ' + error) })
      }
    }
  }
</script>