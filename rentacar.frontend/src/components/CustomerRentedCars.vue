<template>
  <v-table theme="dark" height="70vh" class="pa-4">
    <thead>
      <tr>
        <th class="text-left">Brand</th>
        <th class="text-left">Model</th>
        <th class="text-left">Year</th>
        <th class="text-left">Segment</th>
        <th class="text-left">Fuel</th>
        <th class="text-left">Mileage</th>
        <th class="text-left">Door</th>
        <th class="text-left">Duration</th>
        <th class="text-left">Rented Mileage</th>
        <th class="text-left">Rental Date</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="car in cars" :key="car.id">
        <td>{{ car.brand }}</td>
        <td>{{ car.model }}</td>
        <td>{{ car.year }}</td>
        <td>{{ car.segment }}</td>
        <td>{{ car.fuel }}</td>
        <td>{{ car.mileage }}</td>
        <td>{{ car.doorCount }}</td>
        <td>{{ car.duration }}</td>
        <td>{{ car.rentedMileage }}</td>
        <td>{{ car.rentalDate }}</td>
      </tr>
    </tbody>
  </v-table>
</template>

<script setup>
import { onMounted, ref } from "vue";

const props = defineProps(["props"]);
let cars = ref([]);
onMounted(() => {
  cars.value = [];
  props.props[0].forEach((rental) => {
    rental.car.duration = rental.duration;
    rental.car.rentedMileage = rental.mileage;
    rental.car.rentalDate = rental.rentalDate;

    cars.value.push(rental.car);
  });
});
</script>

<style scoped></style>
