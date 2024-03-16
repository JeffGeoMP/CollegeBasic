const environment = process.env;

module.exports = {
    port: environment.PORT || 3000,
    appKey : environment.APP_KEY,
    servicesUrl : environment.SERVICES_URL
}
