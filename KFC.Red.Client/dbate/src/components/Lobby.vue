<template>
  <v-container fluid class="pa-0">
    <h4 class="display-3">The Lobby</h4>
    <br/>
     <v-layout justify-center>
        <div class="text-xs-center">
          <div>
            <v-btn color="blue" dark large>Join Random Room</v-btn>
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
            axios.get(URL.createChatURL)
            .then(t => {
                console.log(t.data);
                alert(t.data);
            })
            .catch(e => {
                this.error = e.response.data;
            })
        }
    }
}
</script>
