<template>
  <v-row>
    <v-col cols="4">
      <v-form class="pa-5" ref="form">
        <v-text-field v-model="car.brand" label="Brand" required></v-text-field>

        <v-text-field v-model="car.model" label="Model" required></v-text-field>

        <v-text-field v-model="car.year" label="Year" required></v-text-field>

        <v-text-field
          v-model="car.segment"
          label="Segment"
          required
        ></v-text-field>

        <v-text-field v-model="car.fuel" label="Fuel" required></v-text-field>

        <v-text-field
          v-model="car.mileage"
          label="Mileage"
          required
        ></v-text-field>
        <v-select
          v-model="car.doorCount"
          :items="[3, 5]"
          label="Door"
          required
        ></v-select>
        <v-select
          v-model="car.rentalStatus"
          :items="[
            { title: 'Yes', value: true },
            { title: 'No', value: false },
          ]"
          label="Is Rented ?"
          required
        ></v-select>
        <v-btn
          color="primary"
          class="mr-4"
          @click="car.id === 0 ? createCar() : updateCar(car.id)"
        >
          Submit</v-btn
        >
      </v-form>
    </v-col>

    <v-col cols="8">
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
            <th class="text-left">Status</th>
            <th class="text-left" style="width: 40px">#</th>
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
            <td>{{ car.rentalStatus ? "Rented" : "Free" }}</td>
            <td>
              <button @click="editCar(car.id)">
                <v-icon icon="mdi-pencil" color="primary" />
              </button>
              <button @click="deleteCar(car.id)">
                <v-icon color="red" icon="mdi-trash-can" />
              </button>
            </td>
          </tr>
        </tbody>
      </v-table>
    </v-col>
  </v-row>
</template>

<script setup>
import { inject, onMounted, ref } from "vue";
const axios = inject("axios");

let cars = ref([]);
let car = ref({
  id: 0,
  brand: "",
  model: "",
  year: 0,
  segment: "",
  fuel: "",
  mileage: 0,
  doorCount: 0,
  rentalStatus: false,
});
onMounted(() => {
  axios.get("http://localhost:5270/api/Car").then((response) => {
    cars.value = response.data;
  });
});
const createCar = async () => {
  let status = await axios.post("http://localhost:5270/api/Car", car.value);
  if (status) {
    cars.value.push(car.value);
    location.reload();
  }
};
const editCar = (id) => {
  car.value = cars.value.find((c) => c.id === id);
};
const updateCar = async (id) => {
  let status = await axios.put("http://localhost:5270/api/Car", car.value);
  if (status) {
    location.reload();
    let index = cars.value.indexOf(id);
    cars.value.splice(index, 1);
    cars.value.push(car.value);
  }
};
const deleteCar = async (id) => {
  let status = await axios.delete(`http://localhost:5270/api/Car?id=${id}`);
  if (status) {
    let index = cars.value.indexOf(id);
    cars.value.splice(index, 1);
  }
};
</script>

<style scoped></style>
