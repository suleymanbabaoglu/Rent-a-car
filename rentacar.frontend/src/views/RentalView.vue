<template>
  <v-form style="margin-bottom: 20px">
    <v-col cols="12">
      <v-row>
        <v-col cols="6">
          <v-select
            label="Cars"
            :items="cars"
            item-title="brand"
            item-value="id"
            v-model="rental.carId"
          ></v-select>
        </v-col>
        <v-col cols="6">
          <v-select
            label="Customers"
            :items="customers"
            item-title="firstname"
            item-value="id"
            v-model="rental.customerId"
          ></v-select>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="3">
          <v-text-field
            type="number"
            v-model="rental.mileage"
            label="Rent Mileage"
            required
          ></v-text-field>
        </v-col>
        <v-col cols="3">
          <v-text-field
            type="number"
            v-model="rental.duration"
            label="Duration"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="6">
          <v-label>Rental Date</v-label>
          <Datepicker v-model="rental.rentalDate" required></Datepicker>
        </v-col>
      </v-row>
    </v-col>
    <v-col>
      <v-btn color="primary" @click="createRental">Submit</v-btn>
    </v-col>
  </v-form>
  <v-row>
    <v-col cols="12">
      <v-table theme="dark" height="70vh" class="pa-4">
        <thead>
          <tr>
            <th class="text-left">Customer Name</th>
            <th class="text-left">Customer Email</th>
            <th class="text-left">Customer Phone</th>
            <th class="text-left">Brand</th>
            <th class="text-left">Model</th>
            <th class="text-left">Segment</th>
            <th class="text-left">Rented Mileage</th>
            <th class="text-left">Rental Date</th>
            <th class="text-left">Duration</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="rental in rentals" :key="rental.id">
            <td>
              {{ `${rental.customer.firstname} ${rental.customer.lastname}` }}
            </td>
            <td>{{ rental.customer.email }}</td>
            <td>{{ rental.customer.phone }}</td>
            <td>{{ rental.car.brand }}</td>
            <td>{{ rental.car.model }}</td>
            <td>{{ rental.car.segment }}</td>
            <td>{{ rental.mileage }}</td>
            <td>{{ rental.rentalDate }}</td>
            <td>
              {{ rental.duration + (rental.duration > 1 ? " Days" : " Day") }}
            </td>
          </tr>
        </tbody>
      </v-table>
    </v-col>
  </v-row>
</template>

<script setup>
import { inject, onMounted, ref, computed } from "vue";

const axios = inject("axios");

let rentals = ref([]);
let cars = ref([{ brand: "", id: 0 }]);
let customers = ref([{ firstname: "", id: 0 }]);
let rental = ref({
  carId: 0,
  customerId: 0,
  rentalDate: new Date(),
  mileage: 200,
  duration: 1,
});

onMounted(() => {
  axios.get("http://localhost:5270/api/Rental").then((response) => {
    rentals.value = response.data;
  });
  axios.get("http://localhost:5270/api/Car/not-rented").then((response) => {
    response.data.forEach((car) => {
      cars.value.push({
        brand: `${car.brand} - ${car.model} - ${car.segment} Segment - ${car.year} - ${car.mileage} KM - ${car.doorCount} doors`,
        id: car.id,
      });
    });
  });
  axios.get("http://localhost:5270/api/Customer").then((response) => {
    response.data.forEach((customer) => {
      customers.value.push({
        firstname: `${customer.firstname} ${customer.lastname}`,
        id: customer.id,
      });
    });
  });
});

const createRental = async () => {
  let status = await axios.post(
      "http://localhost:5270/api/Rental",
      rental.value
  );
  if (status) {
    customers.value.push(rental.value);
    location.reload();
  }
};
</script>

<style scoped></style>
