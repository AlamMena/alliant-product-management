"use client";

import { Button, Modal, ModalContent, useDisclosure } from "@heroui/react";
import { Icon } from "@iconify-icon/react/dist/iconify.js";
import React, { ReactElement, useState } from "react";

interface ConfirmationModalProps {
  description: string;
  triggerContent: ReactElement<{ onClick?: () => void }>;
  onConfirm: () => void | Promise<void>;
  onCancel?: () => void | Promise<void>;
}
export function ConfirmationModal({
  description,
  triggerContent,
  onConfirm,
}: ConfirmationModalProps) {
  const [isLoading, setIsLoading] = useState(false);
  const { onOpen, isOpen, onOpenChange, onClose } = useDisclosure();

  const handleConfirm = async () => {
    setIsLoading(true);
    await onConfirm();
    setIsLoading(false);
    onClose();
  };
  return (
    <>
      {React.cloneElement(triggerContent, {
        onClick: onOpen,
      })}
      <Modal onOpenChange={onOpenChange} isOpen={isOpen}>
        <ModalContent className="p-8">
          <div className="flex flex-col space-y-2">
            <span className="text-xl font-bold">
              Are you sure you want to delete?
            </span>
            <span className="text-sm  text-foreground-700">{description}</span>
          </div>
          <div className="flex justify-end space-x-4 mt-4">
            <Button
              color="default"
              variant="shadow"
              size="sm"
              onPress={onClose}
            >
              Cancel
            </Button>
            <Button
              isLoading={isLoading}
              onPress={handleConfirm}
              color="danger"
              variant="shadow"
              size="sm"
              startContent={
                <Icon
                  icon="solar:trash-bin-minimalistic-2-outline"
                  width="18"
                  height="18"
                />
              }
            >
              Confirm
            </Button>
          </div>
        </ModalContent>
      </Modal>
    </>
  );
}
