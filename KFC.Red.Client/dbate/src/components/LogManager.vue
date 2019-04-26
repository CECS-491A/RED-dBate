<template>
  <div>
    <v-toolbar flat color="gray">
      <v-toolbar-title>Log Errors</v-toolbar-title>
      <v-divider
        class="mx-2"
        inset
        vertical
      ></v-divider>
      <v-spacer></v-spacer>
      <v-dialog v-model="dialog" max-width="500px">
        <v-card>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12 sm6 md4>
                  <v-text-field v-model="editedItem.log" label="Log"></v-text-field>
                </v-flex>
              </v-layout>
            </v-container>
          </v-card-text>
        </v-card>
      </v-dialog>
    </v-toolbar>
    <v-data-table
      :headers="headers"
      :items="logs"
      class="elevation-1"
    >
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
        <td class="text-xs-right">{{ props.item.logID }}</td>
        <td class="text-xs-right">{{ props.item.logDate }}</td>
        <td class="text-xs-right">{{ props.item.logError }}</td>
        <td class="text-xs-right">{{ props.item.logTarget }}</td>
        <td class="text-xs-right">{{ props.item.loggedUser }}</td>
        <td class="text-xs-right">{{ props.item.CurrentLoggedInUser }}</td>
        <td class="text-xs-right">{{ props.item.loggedUserRequest }}</td>
        
        <td class="justify-center layout px-0">

          <v-icon
            small
            @click="deleteLogError(props.item)"
          >
            delete
          </v-icon>
        </td>
      </template>
    </v-data-table>
    
    
    <v-toolbar flat color="gray">
      <v-toolbar-title>Log Telemetry</v-toolbar-title>
      <v-divider
        class="mx-2"
        inset
        vertical
      ></v-divider>
      <v-spacer></v-spacer>
      <v-dialog v-model="dialog" max-width="500px">
        <v-card>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12 sm6 md4>
                  <v-text-field v-model="editedItem.log" label="Log"></v-text-field>
                </v-flex>
              </v-layout>
            </v-container>
          </v-card-text>
        </v-card>
      </v-dialog>
    </v-toolbar>

    <v-data-table
      :headers="headers2"
      :items="tlogs"
      class="elevation-1"
    >
    
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
        <td class="text-xs-center">{{ props.item.tlogID }}</td>
        <td class="text-xs-center">{{ props.item.tDate }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserLogin }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserLogout }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserPageVisit }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserFunctionalityExecution }}</td>
        <td class="text-xs-center">{{ props.item.tIPAddress }}</td>
        <td class="text-xs-center">{{ props.item.tLocation   }}</td>
        <td class="justify-center layout px-0">

        </td>
      </template>
    </v-data-table>

    <v-alert
          :value="true"
          type="info"
          transition="scale-transition"
      >
          {{response}}
      </v-alert>

      <br />

  </div>

</template>

<script>
import axios from "axios"
import {URL} from '@/services/ConstUrls'
  export default {
    data: () => ({
      headers: [
        {
          text: 'Log',
          align: 'left',
          value: 'name'
        },
        { text: 'Date', value: 'date' },
        { text: 'Error', value: 'error' },
        { text: 'Target', value: 'target' },
        { text: 'User', value: 'user' },
        { text: 'UserRequest', value: 'userrequest' },
      ],
      headers2: [
        {
          text: 'TLog',
          align: 'left',
          value: 'name'
        },
        { text: 'Date', value: 'date' }, 
        { text: 'DateUserLogout', value: 'dateuserlogout' },
        { text: 'DateUserPagevisit', value: 'dateuserpagevisit' },
        { text: 'IPAddress', value: 'ipaddress' },
        { text: 'Location', value: 'location' }
      ],
      
      logs: [],
      tlogs: [],
      editedIndex: -1,
      editedItem: {
        log: 0,
      },
      defaultItem: {
        logID: 0,
        log: '',
      },
      response: ""
    }),
    watch: {
      dialog (val) {
        val || this.close()
      }
    },
    created () {
      this.initializeErrorLogs()
      this.initializeTelemetryLogs()
    },
    methods: {
      initializeTelemetryLogs () {
          var ldata
          var size
          axios.get(URL.displayTelLogsURL).then(logData =>{
            ldata = logData.data
            size = ldata.length    
            for(var i = 0; i<size;i++){
              var logItem = {
                tlogID: i+1,
                tlogObjectID: ldata[i].Id,
                tDate: ldata[i].Date,
                tDateUserLogin: ldata[i].UserLogin, 
                tDateUserLogout: ldata[i].UserLogout,
                tDateUserPageVisit: ldata[i].PageVisit,
                tDateUserFunctionalityExecution: ldata[i].FunctionalityExecution,
                tIPAddress: ldata[i].IPAddress,
                tLocation: ldata[i].Location
              }
              this.tlogs.push(logItem)
            }
          })
      },
      initializeErrorLogs () {
          var ldata
          var size
          axios.get(URL.displayErrorLogsURL).then(logData =>{
            ldata = logData.data
            size = ldata.length           
            for(var i = 0; i<size;i++){
              var logItem = {
                logObjectID: ldata[i].Id,
                logID: i+1,
                logDate: ldata[i].Date, 
                logError: ldata[i].Error,
                logTarget: ldata[i].LineofCode,
                loggedUser: ldata[i].CurrentLoggedInUser,
                loggedUserRequest: ldata[i].UserRequest
              }
              this.logs.push(logItem)
            }
          })
      },
      deleteLogError (item) {
        const index = this.logs.indexOf(item)
        confirm('Are you sure you want to delete this item?') && this.logs.splice(index, 1)
        axios.delete(URL.deleteErrorLogsURL +'?id=' + item.logObjectID)
        .then(q =>{this.response = "Successfuly Deleted!"})
        .catch(e => {this.response = e.data})
      }
    }
  }
</script>