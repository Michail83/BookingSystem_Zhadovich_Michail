const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/Api",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:44324',
        secure: false
    });

    app.use(appProxy);
};
