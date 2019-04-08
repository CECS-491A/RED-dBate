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

          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="close">Cancel</v-btn>
            <v-btn color="blue darken-1" flat @click="save">Save</v-btn>
          </v-card-actions>
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
        <td class="text-xs-center">{{ props.item.logID }}</td>
        <td class="text-xs-center">{{ props.item.logDate }}</td>
        <td class="text-xs-center">{{ props.item.logError }}</td>
        <td class="text-xs-center">{{ props.item.logTarget }}</td>
        <td class="text-xs-center">{{ props.item.loggedUser }}</td>
        <td class="text-xs-center">{{ props.item.CurrentLoggedInUser }}</td>
        <td class="text-xs-center">{{ props.item.loggedUserRequest }}</td>
        
        <td class="justify-center layout px-0">

          <v-icon
            small
            @click="deleteItem(props.item)"
          >
            delete
          </v-icon>
        </td>
      </template>
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize">Reset</v-btn>
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

          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="close">Cancel</v-btn>
            <v-btn color="blue darken-1" flat @click="save">Save</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-toolbar>

    <v-data-table
      :headers="headers"
      :items="tlogs"
      class="elevation-1"
    >
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
        <td class="text-xs-center">{{ props.item.tlogID }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserLogin }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserLogout }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserPageVisit }}</td>
        <td class="text-xs-center">{{ props.item.tDateUserFunct }}</td>
        <td class="text-xs-center">{{ props.item.tIP }}</td>
        <td class="text-xs-center">{{ props.item.tLoc }}</td>
        <td class="justify-center layout px-0">

          <v-icon
            small
            @click="deleteItem(props.item)"
          >
            delete
          </v-icon>
        </td>
      </template>
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize">Reset</v-btn>
      </template>
    </v-data-table>

  </div>

</template>

<script>
import axios from "axios"

  export default {
    data: () => ({
      dialog: false,
      headers: [
        {
          text: 'Log',
          align: 'left',
          sortable: false,
          value: 'name'
        },
        { text: 'log ID', value: 'logID' },
        { text: 'log', value: 'log' },
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
      }
    }),

    watch: {
      dialog (val) {
        val || this.close()
      }
    },

    created () {
      this.initialize()
      this.initialize2()
    },

    methods: {
      initialize () {
          var ldata
          var size
          const url = `http://localhost:5000/api/errorlog/displaylogs`;
          axios.get(url).then(logData =>{
            ldata = logData.data
            size = ldata.length           
            for(var i = 0; i<size;i++){
              var logItem = {
                tlogID: i+1,
                tDateUserLogin: ldata[i].tDateUserLogin, 
                tDateUserLogout: ldata[i].tDateUserLogout,
                tDateUserPageVisit: ldata[i].tDateUserPageVisit,
                tDateUserFunct: ldata[i].tDateUserFunct,
                tIP: ldata[i].tIP,
                tLoc: ""
              }
              this.tlogs.push(logItem)
            }
          })
      },

      initialize2 () {
          var ldata
          var size
          const url = `http://localhost:5000/api/errorlog/displaylogs`;
          axios.get(url).then(logData =>{
            ldata = logData.data
            size = ldata.length           
            for(var i = 0; i<size;i++){
              var logItem = {
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

      deleteItem (item) {
        const index = this.logs.indexOf(item)
        confirm('Are you sure you want to delete this item?') && this.logs.splice(index, 1)
      },

      close () {
        this.dialog = false
        setTimeout(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        }, 300)
      },

      save () {
        if (this.editedIndex > -1) {
          Object.assign(this.logs[this.editedIndex], this.editedItem)
        } else {
          this.logs.push(this.editedItem)
        }
        this.close()
      }
    }
  }
</script>
