<template>
  <div class="sample-api">
    <h1>Sample page fetching data from the SampleDataController</h1>
    <h3>These are the initial values:</h3>
    <ul class="values-list">
      <li v-for="value in values" :key="value.dateFormatted">
        {{ value.dateFormatted }} - {{ value.temperatureC }} - {{ value.summary }}
      </li>
    </ul>
    <button @click="onTryPost">Try POST action</button>
  </div>
</template>

<script>
export default {
  name: 'sample-api',
  data () {
    return {
      values: []
    }
  },
  created () {
    // Send request to the ASP.NET Core application.
    // No need to specify the host:port since it all runs from the same location
    return fetch('/api/SampleData/WeatherForecasts')
      .then(res => res.json())
      .then(data => { this.values = data })
  },
  methods: {
    onTryPost () {
      return fetch('/api/SampleData', { method: 'POST' })
        .then(res => res.json())
        .then(data => { this.values = data })
    }
  }
}
</script>

<style scoped>
.values-list {
  list-style: none;
}
</style>
