<template>
  <div>
    <v-toolbar flat color="white">
      <v-toolbar-title>Question Management</v-toolbar-title>
      <v-divider
        class="mx-2"
        inset
        vertical
      ></v-divider>
      <v-spacer></v-spacer>
      <v-dialog v-model="dialog" max-width="500px">
        <template v-slot:activator="{ on }">
          <v-btn color="primary" dark class="mb-2" v-on="on">New Question</v-btn>
        </template>
        <v-card>
          <v-card-title>
            <span class="headline">{{ formTitle }}</span>
          </v-card-title>

          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12 sm6 md4>
                  <v-text-field v-model="editedItem.question" label="Question"></v-text-field>
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
      :items="questions"
      class="elevation-1"
    >
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
        <td class="text-xs-center">{{ props.item.questionID }}</td>
        <td class="text-xs-center">{{ props.item.question }}</td>
        <td class="justify-center layout px-0">
          <v-icon
            small
            class="mr-2"
            @click="editItem(props.item)"
          >
            edit
          </v-icon>
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
// import { apiURL } from '@/const.js'
  export default {
    data: () => ({
      dialog: false,
      headers: [
        {
          text: 'Question',
          align: 'left',
          sortable: false,
          value: 'name'
        },
        { text: 'Question ID', value: 'questionID' },
        { text: 'Question', value: 'question' },
      ],
      questions: [],
      editedIndex: -1,
      editedItem: {
        question: 0
      },
      defaultItem: {
        questionID: 0,
        question: ''
      }
    }),
    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
      }
    },
    watch: {
      dialog (val) {
        val || this.close()
      }
    },
    created () {
      this.initialize()
    },
    methods: {
      initialize () {
          const url = `${apiURL}/question/randomquestion`
          axios.get(url, 
          {
              params: 
              {
                  questionID: this.$data.questionID,
                  question: this.$data.question
              }
          })
            // missing error handling ?
        // this.questions = [
        //   {
        //       questionID: 1,
        //       question: 'How are you?'
        //   },
        //   {
        //       questionID: 2,
        //       question: "Okay?"
        //   }
        // ]
      },
      editItem (item) {
          const url =  `${apiURL}/question/update`
          axios.put(url,
          {
          })
        // this.editedIndex = this.questions.indexOf(item)
        // this.editedItem = Object.assign({}, item)
        // this.dialog = true
      },
      deleteItem (item) {
        const index = this.questions.indexOf(item)
        confirm('Are you sure you want to delete this item?') && this.questions.splice(index, 1)
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
          Object.assign(this.questions[this.editedIndex], this.editedItem)
        } else {
          this.questions.push(this.editedItem)
        }
        this.close()
      }
    }
  }
</script>