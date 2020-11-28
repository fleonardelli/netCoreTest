FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# Use native linux file polling for better performance
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
WORKDIR /app
ENTRYPOINT [ "dotnet", "watch", "run", "--no-restore", "--urls", "https://0.0.0.0:443"]
