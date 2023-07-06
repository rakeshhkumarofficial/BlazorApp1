// metamaskInterop.js

window.metamaskInterop = {
    isMetaMaskInstalled: function () {
        return typeof window.ethereum !== 'undefined';
    },

    requestAuthentication: async function () {
        if (!window.ethereum) {
            throw new Error('MetaMask is not installed or available.');
        }

        // Request authentication from MetaMask
        const accounts = await window.ethereum.request({ method: 'eth_requestAccounts' });
        return accounts;
    }
};
