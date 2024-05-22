import { ReactNode } from 'react';

interface BackgroundProps {
    children: ReactNode;
}

export default function Background({ children }: BackgroundProps) {
    return (
        <div className="w-full h-full flex items-center justify-center py-20">
            {children}
        </div>
    );
}
