
<script>
  //Importing Bar class from the vue-chartjs wrapper
  import { Bar} from 'vue-chartjs'
  //Exporting this so it can be used in other components
  export default {
    extends: Bar,
    data () {
      return {
        datacollection: {
          //Data to be represented on x-axis
          labels: ['Chat Game','User Dashboard','Log Manager','Question Manager'],
            datasets: [
            {
              label: 'Features',
              backgroundColor: '#f87979',
              pointBackgroundColor: 'white',
              borderWidth: 1,
              pointBorderColor: '#249EBF',
              //Data to be represented on y-axis
              data: [40, 20, 30, 50, 90, 10, 20, 40, 50, 70, 90, 100]
            }
          ]
        },
        //Chart.js options that controls the appearance of the chart
        options: {
          scales: {
            yAxes: [{
                scaleLabel: {
                display: true,
                labelString: 'Amount of times Feature was used'
                },
              ticks: {
                beginAtZero: true
              },
              gridLines: {
                display: true
              }
            }],
            xAxes: [ {
                scaleLabel: {
                display: true,
                labelString: 'Features'
                },
              gridLines: {
                display: false
              }
            }]
            },
        legend: {
            display: true
        },
        responsive: true,
        maintainAspectRatio: false,
        }   
      }
    },
    mounted () {
      //renderChart function renders the chart with the datacollection and options object.
      this.renderChart(this.datacollection, this.options)
    }
  }
</script>