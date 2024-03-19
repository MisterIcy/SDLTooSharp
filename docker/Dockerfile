FROM debian:bookworm-slim

# Install dependencies
RUN apt-get update -y -qq && \
    apt-get install -y -qq libsdl2-dev libsdl2-image-dev \
    libsdl2-mixer-dev libsdl2-ttf-dev wget curl git zip unzip  

WORKDIR /tmp
RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh && \
    chmod +x ./dotnet-install.sh && \
    ./dotnet-install.sh --version latest && \
    rm ./dotnet-install.sh

WORKDIR /app
