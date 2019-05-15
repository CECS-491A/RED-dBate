<template>
    <v-layout justify-center>
        <div class="text-xs-center">
          <div>
            <br/>
            <v-btn id="deleteAccountSSO" color="blue" v-on:click="deleteAccountSSO" dark large>Delete Account SSO</v-btn>
          </div>
        </div>

        <v-alert
          :value="false"
          type="info"
          transition="scale-transition"
        >
          {{response}}
        </v-alert>

    </v-layout> 
</template>

<script>
import axios from "axios"
import {URL} from '@/services/ConstUrls'

export default {
    name: 'deleteAccount',
    data () {
        return {
            response: ''
        }
    },
    methods:{
        //NEED TO FIX
        deleteAccountSSO(){
            axios.post(URL.deleteSSOURL)
            .then(resp => {
                this.response = 'Succesfully Delete';
                localStorage.removeItem('token');
                this.$store.dispatch('actIsSessionStored', {IsSessionStored: false});
                this.$router.push('/home');

            })
            .catch(e => {
                this.response = 'Not able to Delete'; 
            })
        }
    }   
}
</script>
