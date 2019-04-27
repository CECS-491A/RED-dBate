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
        TelemetryLogout(){
            axios.get("https://httpbin.org/ip")
            axios.post("")
            .then(resp => {result => {
                var iAddr = result.data.proggram.split(',');
                this.ip = iAdddr[0];
            }})
            .catch(error => {
                console.log(error.data);
                })
        }
    }
}
</script>