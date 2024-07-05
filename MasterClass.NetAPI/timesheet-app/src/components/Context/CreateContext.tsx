import React, { createContext, useContext } from 'react';

interface MasterclassTimeRegistrationContextType {
    basename: string;
}

const MasterclassTimeRegistrationContext = createContext<MasterclassTimeRegistrationContextType | undefined>(undefined);

export function MasterClassTimeRegistrationContextProvider({ children }: { children: React.ReactNode }) {

    const contextValue: MasterclassTimeRegistrationContextType = {
        basename: 'default_value',
    };

    return <MasterclassTimeRegistrationContext.Provider value={contextValue}>{children}</MasterclassTimeRegistrationContext.Provider>;
}

export function useMasterclassTimeRegistrationContext(): MasterclassTimeRegistrationContextType {
    const context = useContext(MasterclassTimeRegistrationContext);

    if (context === undefined) {
        throw new Error('useYourContext must be used within a YourContextProvider');
    }

    return context;
}

export default MasterclassTimeRegistrationContext;