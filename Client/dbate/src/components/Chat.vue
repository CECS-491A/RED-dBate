<template>
  <div>
    <main>
      <section class="section" id="about">
          <div class="columns has-same-height">
            <div class="column">
              <header>
                <div class="user-count">0</div>
                <h1>Tokyo Chat</h1>
              </header>

              <section class="sidebar">

              </section>
            </div>
            <div class="column is-5">
              <header>
                <h1>Question?</h1>
              </header>

              <section class="chat">
                <ul v-if="messages">
                  <li v-for="item in messages"> <strong>{{item.username}}</strong> : {{item.message}}</li>
                </ul>
              </section>

              <form>
                <input type="text" placeholder="argument" v-model="message" />
                <button v-on:click="sendMessage">Send</button>
              </form>
              <br/>
            </div>
            <div class="column">
              <header>
                <div class="user-count">0</div>
                <h1>Tokyo Chat</h1>
              </header>

              <section class="sidebar">

              </section>
            </div>
          </div>
        </section>
    </main>
  </div>
</template>

<script>
  import $ from 'jquery'
  import 'ms-signalr-client-jquery-3'

  export default {
    name: 'chat',
    data () {
      return {
        username: '',
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
      this.proxy.on('broadcastMessage', (username, message) => {
        console.log('test')
        that.messages.push({username:username, message: message })
      })
      this.connection
        .start({ })
        .done(() => { console.log('Now connected') })
        .fail(() => { console.log('Could not connect') })
    },
    methods: {
      sendMessage () {
        this.proxy.invoke('send', this.username, this.message)
        .done(() => { console.log('Invocation of Send succeeded') })
        .fail(error => { console.log('Invocation of Send failed. Error: ' + error) })
      }
    }
  }
</script>

<style>
 * {
    box-sizing: border-box;
    transition: all .3s ease;
  }

  html, body {
    background: #eee;
    width: 100%;
    height: 100%;
    margin: 0;
    padding: 0;
  }

  main {
    width: calc(100% - 20px);
    /*max-width: 500px;*/
    margin: 10px auto;
    font-family: Helvetica, Arial, Sans, sans-serif;
  }

  h1, .user-count {
    margin: 0;
    padding: 10px 0;
    font-size: 32px;
  }

  .sidebar {
    content: '';
    width: 100%;
    height: calc(80vh - 165px);
    background: white;
    padding: 0;
    margin-right:  0px;
  }

  .chat {
    content: '';
    width: 100%;
    height: calc(100vh - 165px);
    background: white;
    padding: 5px 10px;
  }

  .chat p {
    margin: 0 0 5px 0;
  }

  input, button {
    width: 100%;
    font: inherit;
    background: #fff;
    border: none;
    margin-top: 10px;
    padding: 5px 10px;
  }

  button:hover {
    cursor: pointer;
    background: #ddd;
  }

  @media all and (min-width: 500px) {
    .chat {
      height: calc(100vh - 140px);
    }
    input {
      width: calc(100% - 160px);
    }
    button {
      float: right;
      width: 150px;
    }
  }
</style>
