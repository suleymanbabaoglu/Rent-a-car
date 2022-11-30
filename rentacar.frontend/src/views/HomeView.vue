<template>
  <v-row style="text-align: center">
    <v-col cols="3">
      <Badge color="green" title="Customer" :text="customerCount" :link="'/customer'"/>
    </v-col>
    <v-col cols="3">
      <Badge color="orange" title="Car" :text="carCount" :link="'/car'"/>
    </v-col>
    <v-col cols="3">
      <Badge color="red" title="Rented Car" :text="rentedCount" :link="'/rental'"/>
    </v-col>
  </v-row>
</template>

<script setup>
import Badge from "@/components/Badge.vue";
import { inject, ref, onMounted } from "vue";
const customerCount = ref(0);
const carCount = ref(0);
const rentedCount = ref(0);
const axios = inject("axios");
onMounted(() => {
  axios
    .get("http://localhost:5270/api/Car/rented")
    .then((response) => (rentedCount.value = response.data));
  axios
    .get("http://localhost:5270/api/Car/count")
    .then((response) => (carCount.value = response.data));
  axios
    .get("http://localhost:5270/api/Customer/count")
    .then((response) => (customerCount.value = response.data));
});
</script>
<style scoped></style>
