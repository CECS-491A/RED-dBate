<template>
  <div>
        <!--Header for Error Log -->
    <v-toolbar flat color="gray">
      <v-toolbar-title>Log Errors</v-toolbar-title>
    </v-toolbar>
        <!--Table for Error Log -->
    <v-data-table
      :headers="headers"
      :items="logs"
      class="elevation-1"
    >
    <!-- Header Table Data for Error Log -->
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
        <td class="text-xs-right">{{ props.item.logID }}</td>
        <td class="text-xs-right">{{ props.item.logDate }}</td>
        <td class="text-xs-right">{{ props.item.logError }}</td>
        <td class="text-xs-right">{{ props.item.logTarget }}</td>
        <td class="text-xs-right">{{ props.item.loggedUser }}</td>
        <td class="text-xs-right">{{ props.item.CurrentLoggedInUser }}</td>
        
        <td class="justify-center layout px-0">
          <!--Button to delete for Error Log -->
          <v-icon
            small
            @click="deleteLogError(props.item)"
          >
            delete
          </v-icon>
        </td>
      </template>
    </v-data-table>
    
    <!--Header for Telemetry Log -->
    <v-toolbar flat color="gray">
      <v-toolbar-title>Log Telemetry</v-toolbar-title>
    </v-toolbar>
    
    <!--Table for Telemetry Log -->
    <v-data-table
      :headers="headers2"
      :items="tlogs"
      class="elevation-1"
    >
    <!--Table for Telemetry Log -->
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
        <td class="text-xs-center">{{ props.item.tlogID }}</td>
        <td class="text-xs-center">{{ props.item.tDate }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserLogin }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserLogout }}</td>
        <td class="text-xs-center">{{ props.item.tIPAddress }}</td>
        <td class="justify-center layout px-0">
        </td>
      </template>
    </v-data-table>

<!--Component to convey an important message -->
    <v-alert
          :value="false"
          type="info"
          transition="scale-transition"
      >
          {{response}}
      </v-alert>

      <br />

  </div>

</template>

<!--Retrieving Data from the backend to Error/Telemetry Log -->
<script>
import axios from "axios"
import {URL} from '@/services/ConstUrls'
  export default {
    data: () => ({
      headers: [
        {
          text: 'ErrorLogs#',
          align: 'left',
          value: 'name'
        },
        { text: 'Date', value: 'date' },
        { text: 'Error', value: 'error' },
        { text: 'LineofCode', value: 'target' },
        { text: 'User', value: 'user' },
        { text: 'UserRequest', value: 'userrequest' },
      ],
      headers2: [
        {
          text: 'TelemetryLogs#',
          align: 'left',
          value: 'name'
        },
        { text: 'Date', value: 'date' }, 
        { text: 'DateUserLogin', value: 'dateuserlogin' },
        { text: 'DateUserLogout', value: 'dateuserlogout' },
        { text: 'IPAddress', value: 'ipaddress' },
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
      response: "",
      
    }),

    watch: {
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
                tIPAddress: ldata[i].IPAddress
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