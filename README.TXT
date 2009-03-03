SETUP
=====================================
The first time you run the checkbook application, it will prompt you to select the checkbook database.  Browse to the directory where you unzipped the files, and select "checkbook.mdb".

Once the checkbook application is open, the first thing you need to do is create an account.  To do this, click on "File" and then "New Account".  In the Account Properties dialog, enter a descriptive name for the account, the routing number and the account number.  The comments field is optional, but the account number and
routing number are used when you download transaction data from the bank to make sure that data gets put into the correct account.

Once you have created an account, you will see an item show up in the left hand pane for the account.  If you select this item, you will see a summary screen for the account.  If you expand this item by clicking on the little "+" to the left of it, you'll see two sub items called "Registry" and "Reconcile".  



THE REGISTRY SCREEN
======================================
Clicking on the Registry item displays the Registry screen.  From this screen you can add new bank register entriess, view/edit existing entries, and delete existing entries.  You should have one entry in place after you create the account called "account created".  This is there just to initialize the account balance to zero.

You can navigate your bank entriess in the Registry screen by clicking on the navigation buttons: |<, <, >, >|, + (first, previous, next, last, and new respectively).  You can also navigate by selecting an entry in the transactions list.

When you create a new bank entry, you must specify the transaction date, type, description, and amount.  The check number, cleared, and comment fields are optional.  All amounts should be expressed in positive numbers.  Ex:  A check written for $10.00 is entered as "10", not "-10".  The transaction type specified will automatically determine wether the amount should be added or subtracted from the total.

When you create a new bank entry or edit an existing one, navigating off of the entry causes it to be saved.  

If you want to delete an entry, select it in the transaction list, right click on it and select "Delete".

All entries are sorted by date and at this time there is no search functionality available.



THE RECONCILE SCREEN
======================================
Clicking on the Reconcile item displays the Reconcile screen.  From this screen you can navigate existing regestry entries that have not been marked as cleared and see a list of matching bank transactions.  The matches are based on the amount, so it's possible to see more than one match.  You can also see a list of "What's left".  These are bank transactions that have not been linked to any registry entry.

To reconcile the regestry entry with the bank transaction, double-click on the bank transaction item in the list.  This will mark the entry as cleared and remove the bank transaction from the list.  Navigating off of the entry will cause it to be saved.

Once you have reconciled all of your transactions that have matches, it is handy to look at the "What's left" tab.  The items in the "What's left" list may indicate entries that had the amount entered incorrectly, or they may indicate missing entries.

If you double-click a bank transaction in the "What's left" list, it will create a registry entry based on that transaction for you.  You can then associate that entry with the bank transaction from the "Possible matches" tab.



DOWNLOADING BANK TRANSACTION DATA
======================================
To get you bank transactions into the checkbook program, you must log in to your bank's web site and download the data in Microsoft Money (.ofx) format.  If you're given an option, you want to use the Microsoft Money format for Microsoft Money '98 or newer.  I have not tested the checkbook program with older formats.

When you are prompted to save your bank data, choose "Open with" and select the checkbook application (checkbook.exe) from the directory where you unzipped the files.  Then click OK.

After a moment, you will see a message asking if you want to import bank data into your account.  NOTE:  This is where the routing number and account number must be correct, or the checkbook application will not know what account to import the data into.

Once the data has been imported, the checkbook application will be open, and you can go to the reconcile screen and get to work.



MISC.
======================================
At the bottom of the checkbook application screen, there are three dollar amounts.  One is the balance, one is the cleared balance, and one is the total of future items.  The balance amount is the total of all the entries in the registry.  The cleared balance is the total of all the entries that have been marked as cleared.  The total of future items is the total of all entries that have a transaction date in the future.

Transaction Types:  The following is a list of the transaction types and wether the amount for that type will be added to or subtracted from your balance.

Type				Add/Sub
==================	=======
ATM					Sub
Archive				Add
Correction Credit	Add
Correction Debit	Sub
Debit Card			Sub
Deposit				Add
E-Pay				Sub
Fee					Sub
Transfer In			Add
Transfer Out		Sub
Withdrawal			Sub
Other Debit			Sub
Other Credit		Add

