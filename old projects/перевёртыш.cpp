#include <iostream>
#include <cstring>

using namespace std;

int main(){
    char s[200];
    int c = 0;
    cin >> s;
    for (int i = 0; i < strlen(s) / 2; i++)
        if (s[i] == s[strlen(s) - i - 1]) c++;
    if (c == strlen(s) / 2) cout << "Yes";
       else cout << "No";
    return 0;
}
