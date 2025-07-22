# Azure Resume Challenge

A serverless web application built on Microsoft Azure demonstrating cloud architecture skills. This project showcases a complete cloud-native solution with automated CI/CD deployment.

## 🌐 Live Demo

**Website:** [lpzb.me](https://lpzb.me)  
**API Endpoint:** [GetResumeCounter Function](https://getresumecounter-bfe5cufmayh5dmdk.eastasia-01.azurewebsites.net/api/GetResumeCounter)

## 🏗️ Architecture

```
Frontend (Azure Static Web Apps)
    ↓
Cloudflare CDN & DNS
    ↓
Azure Functions (Visitor Counter API)
    ↓
Azure Cosmos DB (Counter Storage)
```

## 🛠️ Technologies Used

### Frontend
- **HTML5/CSS3/JavaScript** - Responsive resume website
- **Azure Static Web Apps** - Static website hosting with global CDN
- **Cloudflare** - DNS management and performance optimization

### Backend
- **Azure Functions** - Serverless HTTP trigger function
- **C# (.NET 8)** - Function runtime and logic
- **Azure Cosmos DB** - NoSQL database for visitor counter

### DevOps & Deployment
- **GitHub Actions** - CI/CD pipeline automation
- **Git** - Version control

## ✨ Features

- **Responsive Design** - Mobile-first responsive layout
- **Real-time Visitor Counter** - Tracks page visits using Azure Functions + Cosmos DB
- **Custom Domain** - Professional domain with SSL certificate
- **Global CDN** - Fast loading times worldwide via Cloudflare
- **CI/CD Pipeline** - Automated deployment on code changes
- **Serverless Architecture** - Cost-effective and scalable solution

## 🚀 Architecture Components

### 1. Frontend
- Static HTML/CSS/JS resume website
- Hosted on Azure Static Web Apps
- Integrated with Cloudflare for performance and security

### 2. Backend API
- Azure Function with HTTP trigger (`GetResumeCounter`)
- Reads and increments visitor counter
- Returns JSON response to frontend

### 3. Database
- Azure Cosmos DB with SQL API
- Stores visitor counter data
- Automatic scaling and global distribution

### 4. CI/CD Pipeline
- **Frontend**: Automatic deployment via Azure Static Web Apps
- **Backend**: GitHub Actions workflow for Function App deployment
- Service Principal authentication for secure deployments

## 📁 Project Structure

```
azure-resume/
├── frontend/
│   ├── index.html          # Main resume page
│   ├── main.js             # JavaScript for counter functionality
│   ├── css/                # Stylesheets
│   └── images/             # Profile and assets
├── backend/
│   └── api/
│       ├── GetResumeCounter.cs  # Azure Function code
│       ├── Counter.cs           # Data model
│       ├── Program.cs           # Function app configuration
│       └── host.json           # Function host settings
├── .github/
│   └── workflows/
│       ├── deploy-backend.yml              # Backend CI/CD
│       └── azure-static-web-apps-*.yml     # Frontend CI/CD
└── README.md
```

## 🛠️ Local Development

### Prerequisites
- .NET 8 SDK
- Azure Functions Core Tools
- Visual Studio Code (recommended)
- Azure CLI (optional)

### Setup
1. **Clone the repository**
   ```bash
   git clone https://github.com/lukeperry/azure-resume.git
   cd azure-resume
   ```

2. **Backend Development**
   ```bash
   cd backend/api
   func start
   ```
   The API will be available at `http://localhost:7071/api/GetResumeCounter`

3. **Frontend Development**
   ```bash
   cd frontend
   # Serve using your preferred method (Live Server, Python HTTP server, etc.)
   python -m http.server 8000
   ```

### Environment Variables
Create a `local.settings.json` file in the `backend/api` directory:
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CosmosDbConnectionString": "your-cosmos-db-connection-string"
  },
  "Host": {
    "CORS": "*"
  }
}
```

## ☁️ Azure Resources

This project uses the following Azure services:

- **Azure Static Web Apps** (Free tier)
- **Azure Functions** (Consumption plan)
- **Azure Cosmos DB** (Free tier - 1000 RU/s, 25GB)
- **Application Insights** (Included with Functions)

**Estimated Monthly Cost:** $0-5 (within free tiers)

## 🚀 Deployment

### Automatic Deployment
Both frontend and backend deploy automatically via GitHub Actions when changes are pushed to the `main` branch.

### Manual Deployment
1. **Backend**:
   ```bash
   cd backend/api
   func azure functionapp publish GetResumeCounter
   ```

2. **Frontend**: 
   Automatically handled by Azure Static Web Apps

## 🔧 Configuration

### Custom Domain Setup
1. Configure DNS records in Cloudflare
2. Add custom domain in Azure Static Web Apps
3. Wait for SSL certificate provisioning

### CORS Configuration
Configure CORS in Azure Function App settings to allow requests from your domain.

## 📊 Monitoring

- **Application Insights** - Function performance and error tracking
- **Azure Portal** - Resource monitoring and metrics
- **GitHub Actions** - Build and deployment status


## 🙏 Acknowledgments

- **Template**: [CeeVee by StyleShout](https://www.styleshout.com/free-templates/ceevee/)
- **Inspiration**: [Azure Resume Challenge by Forrest Brazeal](https://cloudresumechallenge.dev/)
- **Icons**: Font Awesome

## 📞 Contact

Luke Buenaventura - [lukezabala@gmail.com](mailto:lukezabala@gmail.com)

**Portfolio**: [lpzb.me](https://lpzb.me)  
**LinkedIn**: [lukeperry122](https://www.linkedin.com/in/lukeperry122/)  
**GitHub**: [lukeperry](https://github.com/lukeperry)

---

⭐ **If you found this project helpful, please consider giving it a star!**