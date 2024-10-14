using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

public class SignInWithName : MonoBehaviour
{
    public InputField emailInputField;
    public InputField passwordInputField;
    public Button signInButton;
    public Button signUpButton;
    public Text statusText;

    async void Start()
    {
        // Initialize Unity Gaming Services
        await UnityServices.InitializeAsync();
        Debug.Log("Unity Gaming Services Initialized");
        AutoSignIn();
        signInButton.onClick.AddListener(SignIn);
        signUpButton.onClick.AddListener(SignUp);
    }

    // Function to display status message
    void DisplayStatus(string message)
    {
        statusText.text = message;
        Debug.Log(message);
    }

    // Handle errors
    void HandleError(AuthenticationException authException)
    {
        DisplayStatus($"Authentication Error: {authException.Message}");
    }

    // Handle general errors
    void HandleError(Exception exception)
    {
        DisplayStatus($"Error: {exception.Message}");
    }
    public async void SignUp()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            DisplayStatus("Email and Password must not be empty.");
            return;
        }

        try
        {
            // Register the user
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(email, password);

            DisplayStatus("Sign Up Successful. Please sign in.");
        }
        catch (AuthenticationException authException)
        {
            HandleError(authException);
        }
        catch (RequestFailedException requestFailedException)
        {
            DisplayStatus($"Request Failed: {requestFailedException.Message}");
        }
    }
    public async void SignIn()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            DisplayStatus("Email and Password must not be empty.");
            return;
        }

        try
        {
            // Sign the user in with email and password
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(email, password);
            SceneManager.LoadScene("MenuManager");
            DisplayStatus("Sign In Successful.");
        }
        catch (AuthenticationException authException)
        {
            HandleError(authException);
        }
        catch (RequestFailedException requestFailedException)
        {
            DisplayStatus($"Request Failed: {requestFailedException.Message}");
        }
    }
    public async void SignOut()
    {
        try
        {
            AuthenticationService.Instance.SignOut();
            DisplayStatus("Sign Out Successful.");
        }
        catch (Exception ex)
        {
            DisplayStatus($"Error Signing Out: {ex.Message}");
        }
    }
    private async void AutoSignIn()
    {
        if (AuthenticationService.Instance.IsSignedIn)
        {
            // User is already signed in, no need to sign in again
            DisplayStatus("Auto Sign-In: User already signed in.");
            SceneManager.LoadScene("MenuManager");
            return;
        }
        else
        {
            Debug.Log("Not Sign in yet");
        }

       
    }

}
