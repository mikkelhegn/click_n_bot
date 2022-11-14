# Spin Sample apps

This repository contains two sample application built using Spin, and showcase during the Fermyon November Community call on November 10th 2022.

These sample applications are provided as is, no guarantees, no maintenance, no support, but hopefully some inspiration :-)

- Click
  - An spin application, which showcases how to use multiple components to server static files (a frontend) and an api backend, created using the Rust HTTP template.
  - You click a button on a webpage and a counter in Redis increases, through the backend Spin component calling the Redis host.
  - You need to bring your own Redis. [Redis Labs](https://www.redis.com) is highly recommended and easy to use.

- dotnet_bot
  - A Spin application written using the [dotnet sdk](https://github.com/fermyon/spin-dotnet-sdk).
  - Showcases how to write a Slack bot using an HTTP-triggered Spin component.