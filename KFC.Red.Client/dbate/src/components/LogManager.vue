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
          <v-card-title>
            <span class="headline">{{ formTitle }}</span>
          </v-card-title>

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
        <td class="text-xs-center">{{ props.item.log }}</td>
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
          <v-card-title>
            <span class="headline">{{ formTitle }}</span>
          </v-card-title>

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
        <td class="text-xs-center">{{ props.item.tlog }}</td>
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
        this.logs = [
          {
            logID: 1,
            log: 'error log1'
          },
          {
            logID: 2,
            log: "error log2"
          }
        ]
      },

      initialize2 () {
        this.tlogs = [
          {
            tlogID: 1,
            tlog: 'tele log1'
          },
          {
            tlogID: 2,
            tlog: "tele log2"
          }
        ]
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
