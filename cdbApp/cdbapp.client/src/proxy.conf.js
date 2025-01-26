const { env } = require('process');

let target;
if (env.ASPNETCORE_HTTPS_PORT) {
  target = `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`;
} else if (env.ASPNETCORE_URLS) {
  target = env.ASPNETCORE_URLS.split(';')[0];
} else {
  target = 'https://localhost:7164';
}

const PROXY_CONFIG = [
  {
    context: [
      "/api/cdb",
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
