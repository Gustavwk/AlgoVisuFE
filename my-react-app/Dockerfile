# Use an official Node.js runtime as a parent image
FROM node:16-alpine

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application source code
COPY . .

# Build the application
RUN npm run build

# Install serve to serve the build files
RUN npm install -g serve

# Expose port 3000 to the outside world
EXPOSE 3000

# Command to run the application
CMD ["serve", "-s", "build"]
