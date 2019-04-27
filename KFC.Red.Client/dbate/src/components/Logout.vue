<template>
  <v-container fluid class="pa-0">

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
            axios.post(URL.CreateTelemetryURL)
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