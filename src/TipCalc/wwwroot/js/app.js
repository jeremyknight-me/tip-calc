let deferredInstallPrompt;

window.addEventListener('beforeinstallprompt', (e) => {
    // Prevent the mini-infobar from appearing on mobile
    e.preventDefault();
    // Stash the event so it can be triggered later.
    deferredInstallPrompt = e;
});

window.tipcalc = {
    installApp: async function () {
        if (deferredInstallPrompt) {
            // Show the install prompt
            deferredInstallPrompt.prompt();
            // Wait for the user to respond to the prompt
            const { outcome } = await deferredInstallPrompt.userChoice;
            // Optionally, send analytics event with outcome of user choice
            console.log(`User response to the install prompt: ${outcome}`);
            // We've used the prompt and can't use it again, throw it away
            deferredInstallPrompt = null;
        } else {
            console.warn('Install prompt is not available.');
        }
    }
}
