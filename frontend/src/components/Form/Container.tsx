import { ReactNode } from 'react';
import Button from '../Button';

interface ContainerProps {
    children: ReactNode;
    sendButtonTitle: string;
    onSubmit?: (data: object) => void;
}

export default function Container({
    children,
    sendButtonTitle,
    onSubmit
}: ContainerProps) {
    return (
        <form
            onSubmit={onSubmit}
            className="w-full lg:w-3/5 xl:w-2/5 px-8 lg:px-14 xl:px-16 py-12 lg:py-16 xl:py-20 lg:shadow-[2px_2px_8px_0_rgba(0,0,0,0.2)] lg:rounded-xl bg-gray-900 flex flex-col items-center"
        >
            {children}
            <Button
                title={sendButtonTitle}
                buttonColor="light"
                buttonSize="big"
                isSubmitButton={true}
            />
        </form>
    );
}
