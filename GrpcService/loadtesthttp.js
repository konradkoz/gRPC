import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
  discardResponseBodies: true,
  scenarios: {
    contacts: {
      executor: 'per-vu-iterations',
      vus: 10,
      iterations: 10,
      maxDuration: '30s',
    },
  },
};

const params = {
  responseType: 'text',
};

export default function () {
  const response = http.get('https://localhost:5007/GetEmployeesRest', params);
  console.log(response);
  sleep(1);
}
